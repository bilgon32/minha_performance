import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getUsersList() {
    return this.http.get<User[]>(this.baseUrl + 'api/ApplicationUser');
  }
}
