if ($) {
	/* todo - pass an object, since we're already grabbing values? */
	function validateLoan(number) {
		if (
			(number == 1 || number == 2)
			&& ($('#Loan' + number + 'Name').val() != '')
			&& ($('#Loan' + number + 'Balance').val() != '')
			&& ($('#Loan' + number + 'Payment').val() != '')
			&& ($('#Loan' + number + 'Payments').val() != '')
			&& ($('#Loan' + number + 'Interest').val() != '')
		) {
			return true;
		}
		return false;
	}

	function sampleLoan() {
		$('#Loan1Name').val('Student loan');
		$('#Loan1Balance').val('2984.87');
		$('#Loan1Payment').val('97.85');
		$('#Loan1Payments').val('12');
		$('#Loan1Interest').val('4.25');
	}

	/* todo */
	function copyLoan(numberFrom, numberTo) {
		if ((numberFrom == 1 || numberFrom == 2) && (numberTo == 1 || numberTo == 2)) {
			/* todo - objects? */
			$('#Loan' + numberTo + 'Name').val($('#Loan' + numberFrom + 'Name').val());
			$('#Loan' + numberTo + 'Balance').val($('#Loan' + numberFrom + 'Balance').val());
			$('#Loan' + numberTo + 'Payment').val($('#Loan' + numberFrom + 'Payment').val());
			$('#Loan' + numberTo + 'Payments').val($('#Loan' + numberFrom + 'Payments').val());
			$('#Loan' + numberTo + 'Interest').val($('#Loan' + numberFrom + 'Interest').val());
		}
	}

	function clearLoan(number) {
		if (number == 1 || number == 2) {
			var idBase = '#Loan' + number;
			$(idBase + 'Name').val('');
			$(idBase + 'Balance').val('');
			$(idBase + 'Payment').val('');
			$(idBase + 'Payments').val('');
			$(idBase + 'Interest').val('');
		}
	}

	function generateLoan(number) {
		if (validateLoan(number)) {
			var loanName = $('#Loan' + number + 'Name').val();
			var loanBalance = $('#Loan' + number + 'Balance').val();
			var loanPayment = $('#Loan' + number + 'Payment').val();
			var loanPayments = $('#Loan' + number + 'Payments').val();
			var loanInterest = $('#Loan' + number + 'Interest').val();
			$('#Loan' + number + 'Data').html('');

			try {
				$.ajax({
					type: "GET",
					url: 'http://services.jamesrskemp.com/FormulasService/Loan?name=' + loanName + '&total=' + loanBalance + '&payment=' + loanPayment + '&yearlyPayments=' + loanPayments + '&yearlyInterest=' + loanInterest + '',
					dataType: 'jsonp',
					success: function (data) { processData(data, number); },
				});
			} catch (ex) {
				$('#Loan' + number + 'Data').html('<p class="error">Error: ' + ex.Message + '</p>');
			}
		} else {
			$('#Loan' + number + 'Data').html('<p class="error">Please verify the data entered for this loan and re-submit after correcting.</p>');
		}
	}

	function processData(data, loanNumber) {
		try {
			// JavaScript will go either here - in the *function*
			var outputContent = "<h3>Loan " + loanNumber + " payments</h3>";
			outputContent += "Loan name: " + data.Name + "<br />";
			outputContent += "Starting balance: $" + data.Total + "<br />";
			outputContent += "Total payments: " + data.Payments.length + "<br />";
			outputContent += "<ol>";
			$.each(data.Payments, function (i, payment) { outputContent += '<li>After a payment of <span class="loanPayment">$' + payment.Total.toFixed(2) + '</span>, the remaining amount is <span class="loanRemaining">$' + payment.LoanRemaining.toFixed(2) + '</span></li>'; });
			outputContent += "</ol>";
			$('#Loan' + loanNumber + 'Data').html(outputContent);
		} catch (ex) {
			alert("Error: " + ex.Message);
		}
	}

	$(window).load(function () {
		$('#Loan1Submit').removeAttr('disabled').click(function () { generateLoan(1); });
		$('#Loan1Clear').removeAttr('disabled').click(function () { clearLoan(1); });
		$('#Loan2Submit').removeAttr('disabled').click(function () { generateLoan(2); });
		$('#Loan2Clear').removeAttr('disabled').click(function () { clearLoan(2); });

		$('#LoanSample').html('<a href="#" onclick="sampleLoan();return false;">Sample loan</a>');
		$('#Loan1Copy').html('<a href="#" onclick="copyLoan(2, 1);return false;">Copy from loan 2</a>');
		$('#Loan2Copy').html('<a href="#" onclick="copyLoan(1, 2);return false;">Copy from loan 1</a>');

	});
}