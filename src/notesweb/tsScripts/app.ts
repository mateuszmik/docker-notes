import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {NotificationsService} from "./notifications.service";

@Component({
    selector: 'my-app',
    template: `    
    <h1>sample app to display notifications</h1>
    <h2>Notifications:</h2>
    <ul>
      <li *ngFor="let notification of notifications">
        {{ notification }}
      </li>
    </ul>
  `
})
export class AppComponent {
    title = 'Example of NotificationService with docker';
    notifications = [];

    constructor(private readonly notificationsService: NotificationsService) {
        this.notificationsService
            .getMessages()
            .subscribe(data => {
                this.notifications = data;
            });
    }
}