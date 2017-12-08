import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app';
import { NotificationsService } from "./notifications.service";
import { HttpModule } from '@angular/http';

@NgModule({
    imports: [BrowserModule, HttpModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent],
    providers: [NotificationsService]
})
export class AppModule { }