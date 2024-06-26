import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AmountConverterComponent } from './components/amount-converter/amount-converter.component';
import { AmountInputComponent } from './components/amount-input/amount-input.component';
import { ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from './shared/material/material.module';
import { AmountConverterService } from './shared/services/amount-converter.service';

@NgModule({
  declarations: [
    AppComponent, AmountConverterComponent, AmountInputComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, ReactiveFormsModule, MaterialModule
  ],
  providers: [
    provideAnimationsAsync(), AmountConverterService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
