import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Rx";

@Injectable()
export class NotificationsService {
    constructor(private readonly http: Http) { }

    public getMessages() {
        const dataContainer = document.getElementById("server-data");
        const url = dataContainer.dataset["notificationsUrl"];
        return Observable.interval(5000).flatMap(() => {
                return this.http
                    .get(url)
                    .map(response => response.json());
            });
    }
}