﻿using CarBookProject.Application.Feautures.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
		public UpdateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Please do not leave the customer name blank!");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Please enter at least 5 characters of data!");
			RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Please do not leave the rate value empty.");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Please do not leave the comment value empty.");
			RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Please enter at least 50 characters of data in the comment section.");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Please enter a maximum of 500 characters in the comment section.");
			RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Please do not leave the customer image blank!").MinimumLength(10).WithMessage("Lütfen en az 10 karakter uzunluğunda veri girişi yapınız!").MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter uzunluğunda veri girişi yapınız!");
		}
	}
}