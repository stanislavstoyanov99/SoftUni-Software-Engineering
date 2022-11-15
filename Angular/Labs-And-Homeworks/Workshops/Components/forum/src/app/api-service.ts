import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { IPost } from "./models/IPost";
import { ITheme } from "./models/ITheme";

const apiURL = environment.apiURL;

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    constructor(private httpClient: HttpClient) {}

    loadThemes() {
        return this.httpClient.get<ITheme[]>(`${apiURL}/themes`);
    }

    loadPosts(limit?: number) {
        return this.httpClient.get<IPost[]>(`${apiURL}/posts${limit ? `?limit=${limit}` : ''}`);
    }
}