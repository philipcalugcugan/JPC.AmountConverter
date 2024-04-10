import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { AmountConverterResponseDto } from '../../shared/interface/amount-converter-dto';
import { AmountConverterService } from '../../shared/services/amount-converter.service';

@Component({
	selector: 'app-amount-converter',
	templateUrl: 'amount-converter.component.html',
	styleUrls: ['./amount-converter.component.scss'],
})

export class AmountConverterComponent implements OnInit {
	amountInWords$: Observable<AmountConverterResponseDto>;

	constructor(private route: ActivatedRoute,
		private amountConverterService: AmountConverterService,
	) {}

	ngOnInit() {
		this.amountInWords$ = this.route.params.pipe(
			switchMap((params) => {
			  return this.amountConverterService.convertAmountToWords(params['amount']).pipe();
			}),
		  );
	 }
}
