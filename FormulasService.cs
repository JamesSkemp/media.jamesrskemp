using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// begin additions
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.ComponentModel;
// end additions, although the following one is too
using JamesRSkemp.Formulas;

namespace JamesRSkemp.Media.Web {
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class FormulasService {

		// todo - remove
		// need at least one method - may as well create a dummy one for validation
		[WebGet(UriTemplate = "Dummy")]
		[Description("Dummy operation.")]
		public String DummyMethod() {
			return "It works.";
		}

		// http://localhost:50996/FormulasService/Loan?name=asdf&total=4956.24&payment=97.85&yearlyPayments=12&yearlyInterest=4.25

		[WebGet(UriTemplate = "Loan?name={name}&total={amount}&payment={payment}&yearlyPayments={paymentsPerYear}&yearlyInterest={interestPerYear}")]
		[Description("Create a new loan with set properties")]
		public Amortization.Loan CreateLoan(String name, String amount, String payment, String paymentsPerYear, String interestPerYear) {
			Double loanAmount, loanPayment, loanInterest;
			int loanPaymentsPerYear;

			Double.TryParse(amount, out loanAmount);
			Double.TryParse(payment, out loanPayment);
			int.TryParse(paymentsPerYear, out loanPaymentsPerYear);
			Double.TryParse(interestPerYear, out loanInterest);

			// todo - validation of items > 0

			// todo - validation that the loan terms make sense (interest < payments)

			// If everything looks okay, create a new loan.
			Amortization.Loan newLoan = new Amortization.Loan();
			newLoan.Name = name;
			newLoan.Total = loanAmount;
			newLoan.PaymentAmount = loanPayment;
			newLoan.PaymentsPerYear = loanPaymentsPerYear;
			newLoan.InterestPerYear = loanInterest;

			try {
				newLoan.UpdatePayments();
			} catch (Exception ex) {
				newLoan.Name = ex.Message + " | " + ex.StackTrace;
				// todo, throw appropriate error here
			}

			return newLoan;
		}
	}
}