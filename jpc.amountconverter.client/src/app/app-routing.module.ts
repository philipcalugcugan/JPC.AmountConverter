import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AmountConverterComponent } from './components/amount-converter/amount-converter.component';
import { AmountInputComponent } from './components/amount-input/amount-input.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    children: [
        { path: '', redirectTo: 'amount-input', pathMatch: 'full' }, // Default route
        { path: 'amount-input', component: AmountInputComponent },
        { path: 'amount-converter/:amount', component: AmountConverterComponent },
    ],
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
