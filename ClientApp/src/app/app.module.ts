import { BrowserModule } from '@angular/platform-browser';
import { Component, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { DriversComponent } from './features/drivers/drivers.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { CarFleetMapComponent } from './car-fleet-map/car-fleet-map.component';
import { HeaderComponent } from './header/header.component';
import { ApiService } from './services/api.service';
import { DriverAddComponent } from './features/driver-add/driver-add.component';
import { DriverUpdateComponent } from './features/driver-update/driver-update.component';

@NgModule({
  declarations: [
    AppComponent,
    DriversComponent,
    CarFleetMapComponent,
    HeaderComponent,
    DriverAddComponent,
    DriverUpdateComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', pathMatch: 'full', redirectTo: 'drivers' },
      {
        path: 'drivers',
        children: [
          { path: '', component: DriversComponent },
          { path: 'add', component: DriverAddComponent },
          { path: ':id', component: DriverUpdateComponent }
        ]
      },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    ApiService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
