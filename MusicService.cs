using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using JamesRSkemp.Music;
using System.Web.Hosting;
using System.Configuration;
using System.ComponentModel;
using System.Web;

namespace JamesRSkemp.Media.Web {
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[JavascriptCallbackBehavior(UrlParameterName = "callback")]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class MusicService {

		/// <summary>
		/// Full path to the Xml file to use for data.
		/// </summary>
		String musicXml = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["musicXmlLocation"].ToString());

		/*
		New items to create:
			return tracks never played
				currently part of Plays, but shouldn't be - Plays should change to different method
			return tracks with a particular title
			verify plays ordering is okay
			either tweaks Plays/Date to allow for basing this on the last track's play date, or create new method to do so (instead of by today)
				
				
				
			items currently don't sort, but should
			data should be cached if possible - see how it impacts memory and performance (the latter is pretty quick)
		*/

		[WebGet(UriTemplate = "Testing/ReturnText/{text}")]
		[Description("Return whatever text is passed.")]
		public String ReturnText(String text) {
			return text;
		}

		#region Xml Information
		[WebGet(UriTemplate = "Data/UpdateDate")]
		[Description("Get the date and time the data was last updated.")]
		public String GetFileDate() {
			return Track.GetUpdateDate(musicXml).ToString();
		}
		#endregion

		#region Artists
		[WebGet(UriTemplate = "Artists")]
		[Description("Get a listing of artists, and a count of tracks by them.")]
		public List<ArtistCount> GetArtists() {
			return Track.GetTracks(musicXml).GroupBy(t => t.Artist).Select(t => new ArtistCount { Artist = t.Key, Count = t.Count() }).OrderBy(t => t.Artist).ToList();
		}

		/// <summary>
		/// Gets a listing of tracks by a particular artist.
		/// </summary>
		/// <param name="artist">Exact name of the artist to return tracks for.</param>
		/// <returns>List of Track by particular artist.</returns>
		[WebGet(UriTemplate = "Artists/{artist}")]
		[Description("Get a listing of tracks by a particular artist.")]
		public List<Track> GetArtistTracks(String artist) {
			return Track.GetTracks(musicXml).Where(t => t.Artist == artist).ToList();
		}

		[WebGet(UriTemplate = "Artists/{artist}/Ratings")]
		[Description("Get all ratings used for a particular artist.")]
		public List<RatingCount> GetArtistRatings(String artist) {
			return GetArtistTracks(artist).Where(t => t.Rating != null).GroupBy(t => t.Rating).Select(t => new RatingCount { Rating = (t.Key ?? 0), Count = t.Count() }).OrderByDescending(t => t.Rating).ToList();
		}

		[WebGet(UriTemplate = "Artists/{artist}/Ratings/{rating}")]
		[Description("Get a listing of tracks by a particular artist, that have been given a particular rating.")]
		public List<Track> GetArtistRatingTracks(String artist, String rating) {
			return GetArtistTracks(artist).Where(t => t.Rating == int.Parse(rating)).ToList();
		}

		[WebGet(UriTemplate = "Artists/{artist}/Albums")]
		[Description("Get a listing of albums, with counts, for a particular artist.")]
		public List<AlbumCount> GetArtistsAlbums(String artist) {
			return GetArtistTracks(artist).GroupBy(t => t.Album).Select(t => new AlbumCount { Album = t.Key.TrimEnd(), Count = t.Count() }).ToList();
		}

		[WebGet(UriTemplate = "Artists/{artist}/Albums/{album}")]
		[Description("Get a listing of tracks for a particular album, by a particular artist.")]
		public List<Track> GetArtistsAlbumTracks(String artist, String album) {
			return GetArtistTracks(artist).Where(t => t.Album.TrimEnd() == album).ToList();
		}

		#endregion

		#region Albums
		[WebGet(UriTemplate = "Albums")]
		[Description("Get a listing of albums, with a count of tracks.")]
		public List<AlbumCount> GetAlbums() {
			return Track.GetTracks(musicXml).GroupBy(t => t.Album).Select(t => new AlbumCount { Album = t.Key, Count = t.Count() }).ToList();
		}

		[WebGet(UriTemplate = "Albums/{album}")]
		[Description("Get a listing of tracks for a particular album.")]
		public List<Track> GetAlbumTracks(String album) {
			return Track.GetTracks(musicXml).Where(t => t.Album.TrimEnd() == album).ToList();
		}

		[WebGet(UriTemplate = "Albums?album={album}")]
		[Description("Get a listing of tracks for a particular album.")]
		public List<Track> GetAlbumTracksQueryString(String album) {
			album = HttpUtility.UrlDecode(album);
			return Track.GetTracks(musicXml).Where(t => t.Album == album).ToList();
		}
		#endregion

		#region Ratings
		[WebGet(UriTemplate = "Ratings")]
		[Description("Get a listing of ratings, with the number of tracks with that rating.")]
		public List<RatingCount> GetRatings() {
			return Track.GetTracks(musicXml).GroupBy(t => t.Rating).Select(t => new RatingCount { Rating = (t.Key ?? 0), Count = t.Count() }).OrderByDescending(t => t.Rating).ToList();
		}

		[WebGet(UriTemplate = "Ratings/{rating}")]
		[Description("Get a listing of tracks with a particular rating. Returns a maximum of 1000 tracks.")]
		public List<Track> GetRatingTracks(String rating) {
			return Track.GetTracks(musicXml).Where(t => t.Rating == int.Parse(rating)).Take(1000).ToList();
		}

		[WebGet(UriTemplate = "Ratings/{rating}/{page}")]
		[Description("Get a listing of tracks with a particular rating. Returns 1000 records per page.")]
		public List<Track> GetRatingTracksPaged(String rating, String page) {
			return Track.GetTracks(musicXml).Where(t => t.Rating == int.Parse(rating)).Skip((int.Parse(page) - 1) * 1000).Take(1000).ToList();
		}
		#endregion

		#region Added
		[WebGet(UriTemplate = "Added/{year}")]
		[Description("Get a listing of tracks that were last played in a particular year.")]
		public List<Track> GetTracksAddedYear(String year) {
			return Track.GetTracks(musicXml).Where(t => t.DateAdded != null && ((DateTime)t.DateAdded).Year == int.Parse(year)).OrderByDescending(t => t.DateAdded).ToList();
		}

		[WebGet(UriTemplate = "Added/{year}/{month}")]
		[Description("Get a listing of tracks that were last played in a particular year and month.")]
		public List<Track> GetTracksAddedYearMonth(String year, String month) {
			return GetTracksAddedYear(year).Where(t => t.DateAdded != null && ((DateTime)t.DateAdded).Month == int.Parse(month)).OrderByDescending(t => t.DateAdded).ToList();
		}
		#endregion

		#region Genres
		[WebGet(UriTemplate = "Genres")]
		[Description("Get a listing of music genres, with the number of tracks given that genre.")]
		public List<GenreCount> GetGenres() {
			return Track.GetTracks(musicXml).GroupBy(t => t.Genre).Select(t => new GenreCount { Genre = t.Key, Count = t.Count() }).OrderBy(t => t.Genre).ToList();
		}

		[WebGet(UriTemplate = "Genres/{genre}")]
		[Description("Get a listing of tracks in a particular genre.")]
		public List<Track> GetGenreTracks(String genre) {
			return Track.GetTracks(musicXml).Where(t => t.Genre == genre).ToList();
		}
		#endregion

		#region Played
		[WebGet(UriTemplate = "Played/{year}")]
		[Description("Get a listing of tracks that were last played in a particular year.")]
		public List<Track> GetTracksPlayedYear(String year) {
			return Track.GetTracks(musicXml).Where(t => t.LastPlayed != null && ((DateTime)t.LastPlayed).Year == int.Parse(year)).OrderByDescending(t => t.LastPlayed).ToList();
		}

		[WebGet(UriTemplate = "Played/{year}/{month}")]
		[Description("Get a listing of tracks that were last played in a particular year and month.")]
		public List<Track> GetTracksPlayedYearMonth(String year, String month) {
			return GetTracksPlayedYear(year).Where(t => t.LastPlayed != null && ((DateTime)t.LastPlayed).Month == int.Parse(month)).OrderByDescending(t => t.LastPlayed).ToList();
		}
		#endregion

		#region Plays
		[WebGet(UriTemplate = "Plays/Count/{count}")]
		[Description("Get the last x tracks played, ordered by the last date played.")]
		public List<Track> GetTracksPlayedLast(String count) {
			return Track.GetTracks(musicXml).OrderByDescending(t => t.LastPlayed).Take(int.Parse(count)).ToList();
		}

		[WebGet(UriTemplate = "Plays/Date/{days}")]
		[Description("Get a listing of tracks, ordered by the last date played, over the last x days.")]
		public List<Track> GetTracksByPlayDate(String days) {
			return Track.GetTracks(musicXml).Where(t => t.LastPlayed >= DateTime.Now.AddDays(-int.Parse(days))).OrderByDescending(t => t.LastPlayed).ToList();
		}

		[WebGet(UriTemplate = "Plays/Track/{count}")]
		[Description("Get a listing of x tracks, ordered by the number of times if was played.")]
		public List<Track> GetTracksByPlays(String count) {
			if (count.ToLower() == "never") {
				return Track.GetTracks(musicXml).Where(t => t.PlayCount == 0).ToList();
			} else {
				return Track.GetTracks(musicXml).OrderByDescending(t => t.PlayCount).Take(int.Parse(count)).ToList();
			}
		}
		#endregion

		#region Years
		[WebGet(UriTemplate = "Years")]
		[Description("Get a listing of years of tracks, with the number of tracks with that year.")]
		public List<YearCount> GetYears() {
			return Track.GetTracks(musicXml).GroupBy(t => t.Year).Select(t => new YearCount { Year = (t.Key ?? 0), Count = t.Count() }).OrderByDescending(t => t.Year).ToList();
		}

		[WebGet(UriTemplate = "Years/{year}")]
		[Description("Get a listing of tracks released in a particular year.")]
		public List<Track> GetYearsTracks(String year) {
			return Track.GetTracks(musicXml).Where(t => t.Year == int.Parse(year)).ToList();
		}
		#endregion

		#region Track titles

		[WebGet(UriTemplate = "Titles?title={title}&album={album}&artist={artist}")]
		[Description("Get a listing of tracks with a particular title/name, and album and/or artist.")]
		public List<Track> GetTracksQueryString(String title, String album, String artist) {
			//title = System.Web.HttpUtility.UrlDecode(title);
			//album = System.Web.HttpUtility.UrlDecode(album);
			//artist = System.Web.HttpUtility.UrlDecode(artist);

			if (String.IsNullOrWhiteSpace(title)) {
				throw new WebFaultException(System.Net.HttpStatusCode.NotImplemented);
			} else if (String.IsNullOrWhiteSpace(album) && String.IsNullOrWhiteSpace(artist)) {
				return GetTitleTracks(title);
			} else if (String.IsNullOrWhiteSpace(album)) {
				return GetTitleArtistTracks(title, artist);
			} else if (String.IsNullOrWhiteSpace(artist)) {
				return GetTitleAlbumTracks(title, album);
			} else {
				return Track.GetTracks(musicXml).Where(t => t.Name == title && t.Album == album && t.Artist == artist).ToList();
			}
		}

		[WebGet(UriTemplate = "Titles/{title}")]
		[Description("Get a listing of tracks with a particular title/name.")]
		public List<Track> GetTitleTracks(String title) {
			return Track.GetTracks(musicXml).Where(t => t.Name == title).ToList();
		}

		[WebGet(UriTemplate = "Titles/{title}/Albums/{album}")]
		[Description("Get a listing of tracks with a particular title/name, from a particular album.")]
		public List<Track> GetTitleAlbumTracks(String title, String album) {
			return Track.GetTracks(musicXml).Where(t => t.Name == title && t.Album == album).ToList();
		}

		[WebGet(UriTemplate = "Titles/{title}/Artists/{artist}")]
		[Description("Get a listing of tracks with a particular title/name, by a particular artist.")]
		public List<Track> GetTitleArtistTracks(String title, String artist) {
			return Track.GetTracks(musicXml).Where(t => t.Name == title && t.Artist == artist).ToList();
		}

		/*
			TODO:
			/Titles
			/Titles/{title}/Albums
			/Titles/{title}/Artists
			/Titles/?title={title}&album={album}&artist={artist} (and just check for those that aren't defined?)
		*/

		#endregion

		#region Custom objects returned by methods.
		/// <summary>
		/// Artist name with a count of tracks by that artist.
		/// </summary>
		public class ArtistCount {
			/// <summary>
			/// Name of an artist.
			/// </summary>
			public String Artist { get; set; }
			/// <summary>
			/// Tracks by the artist.
			/// </summary>
			public int Count { get; set; }
		}

		/// <summary>
		/// Album name with a count of tracks in it, across all discs.
		/// </summary>
		public class AlbumCount {
			/// <summary>
			/// Name of the album.
			/// </summary>
			public String Album { get; set; }
			/// <summary>
			/// Total number of tracks in the album, across all discs.
			/// </summary>
			public int Count { get; set; }
		}

		/// <summary>
		/// Genre with a count of tracks assigned it.
		/// </summary>
		public class GenreCount {
			/// <summary>
			/// Name of the genre.
			/// </summary>
			public String Genre { get; set; }
			/// <summary>
			/// Tracks of this genre.
			/// </summary>
			public int Count { get; set; }
		}

		/// <summary>
		/// Rating value with a count of tracks using that rating.
		/// </summary>
		public class RatingCount {
			/// <summary>
			/// Rating between 0 and 5, inclusive.
			/// </summary>
			public int Rating { get; set; }
			/// <summary>
			/// Number of tracks with that rating.
			/// </summary>
			public int Count { get; set; }
		}

		/// <summary>
		/// Four digit years with a count of tracks released that year.
		/// </summary>
		public class YearCount {
			/// <summary>
			/// Four digit year of track or album the track is on.
			/// </summary>
			public int Year { get; set; }
			/// <summary>
			/// Number of tracks released that year.
			/// </summary>
			public int Count { get; set; }
		}

		#endregion

	}
}