import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
	selector: 'amount-input',
	templateUrl: 'amount-input.component.html',
	styleUrls: ['./amount-input.component.scss'],
})

export class AmountInputComponent implements OnInit {
	amountForm: FormGroup;

	constructor(private fb: FormBuilder,
		private router: Router
	) {}

	ngOnInit() {
		this.amountForm = this.fb.group({
            amount: ['', Validators.required]
        });
	 }

	submitForm() {
        // Get the entered amount
        const enteredAmount = this.amountForm.value.amount;

        // Navigate to AmountConverterComponent with the entered amount as a route parameter
        this.router.navigate(['/amount-converter', enteredAmount]);
    }
}