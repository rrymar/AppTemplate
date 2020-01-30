import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UsersModule } from './users/users.module';
import { NgxsModule } from '@ngxs/store';
import { environment } from 'environments/environment';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    NgxsModule.forRoot([], { developmentMode: !environment.production }),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    UsersModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
