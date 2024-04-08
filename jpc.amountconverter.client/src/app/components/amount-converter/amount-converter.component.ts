import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AmountConverterResponseDto, AmountConverterServiceProxy } from '../../shared/services/service-proxies/service-proxies';
import { Observable, switchMap, tap } from 'rxjs';

@Component({
	selector: 'app-amount-converter',
	templateUrl: 'amount-converter.component.html',
	styleUrls: ['./amount-converter.component.scss'],
})

export class AmountConverterComponent implements OnInit {
	amountInWords$: Observable<AmountConverterResponseDto>;

	constructor(private route: ActivatedRoute,
		private amountConverterService: AmountConverterServiceProxy,
	) {}

	ngOnInit() {
		this.amountInWords$ = this.route.params.pipe(
			switchMap((params) => {
			  return this.amountConverterService.convertAmountToWords(params['amount']).pipe();
			}),
		  );
	 }
}
