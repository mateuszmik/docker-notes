import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
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
    title = 'ASP.NET MVC 5 with Angular 2234';
    notifications = ['Notification 1', 'Notification 2', 'Notification 3', 'Notification 4'];

}