import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs";
import 'rxjs/add/operator/toPromise';

@Injectable()
export class NotificationsService {
    private readonly url = "http://notifications:1234/Messages";

    constructor(private readonly http: Http) { }

    public getMessages() {
        return this.http
            .get(this.url)
            .toPromise()
            .then((r: Response) => {
                return r.json() as string[];
            })
            .catch((error) => Promise.reject(error));
    }
}