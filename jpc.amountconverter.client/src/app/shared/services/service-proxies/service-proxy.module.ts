import { NgModule } from '@angular/core';
import { API_BASE_URL } from './service-proxies';
import * as ApiServiceProxies from './service-proxies';
const { env } = require('process');
const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7141';

@NgModule({
    providers: [
      ApiServiceProxies.AmountConverterServiceProxy,
      { provide: API_BASE_URL, useFactory: () => 
        target },
    ],
  })
  export class ServiceProxyModule {}
  