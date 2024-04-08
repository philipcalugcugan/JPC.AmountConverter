import { NgModule } from '@angular/core';
import { API_BASE_URL } from './service-proxies';
import * as ApiServiceProxies from './service-proxies';
const target = 'http://localhost:5011';

@NgModule({
    providers: [
      ApiServiceProxies.AmountConverterServiceProxy,
      { provide: API_BASE_URL, useFactory: () => 
        target },
    ],
  })
  export class ServiceProxyModule {}
  