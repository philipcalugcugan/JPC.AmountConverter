import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { AmountConverterResponseDto } from '../interface/amount-converter-dto';

@Injectable({
  providedIn: 'root',
})
export class AmountConverterService {
  private apiUrl = 'http://localhost:5011/AmountConverter/api/ConvertAmountToWords';

  constructor(private httpClient: HttpClient) {}

  convertAmountToWords(amount: number): Observable<AmountConverterResponseDto> {
    const url = `${this.apiUrl}/${amount}`;
    return this.httpClient.get<AmountConverterResponseDto>(url).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    // Handle the error here
    return throwError(() => new Error('Something went wrong. Please try again later.'));
  }
}