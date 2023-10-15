import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { MyFeedbackSummaryComponent } from './home/my-feedback-summary/my-feedback-summary.component';
import { MyFeedbackComponent } from './my-feedback/my-feedback.component';
import { SendFeedbackComponent } from './send-feedback/send-feedback.component';
import { ViewFeedbackComponent } from './view-feedback/view-feedback.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    MyFeedbackSummaryComponent,
    MyFeedbackComponent,
    SendFeedbackComponent,
      ViewFeedbackComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, canActivate: [AuthorizeGuard] },
      { path: 'my-feedback', component: MyFeedbackComponent, canActivate: [AuthorizeGuard] },
      { path: 'send-feedback', component: SendFeedbackComponent, canActivate: [AuthorizeGuard] },
      { path: 'view-feedback/:id', component: ViewFeedbackComponent, canActivate: [AuthorizeGuard] },
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', redirectTo: '/home', pathMatch: 'full' }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

