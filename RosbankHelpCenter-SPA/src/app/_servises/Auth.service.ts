import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ExpansionCase } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/questions/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  answer: any;
  defaultString = 'Where is my answer?';
  ExactlySolWasFound = false;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          console.log(this.decodedToken);
        }
      })
    );
  }

  feedback(model: any) {
    return this.http.post(this.baseUrl + 'q_q', model).pipe(
      map((response: any) => {
        const answer = response;
        if (answer) {
          this.answer = answer;
          localStorage.setItem('answer1', this.answer[0].answer);
          localStorage.setItem('answer2', this.answer[1].answer);
          localStorage.setItem('answer3', this.answer[2].answer);
        }
        if (answer[1] == null) {
          this.ExactlySolWasFound = true;
        } else {
          localStorage.setItem('answer1', this.answer[0].answer);
          localStorage.setItem('answer2', this.answer[1].answer);
          localStorage.setItem('answer3', this.answer[2].answer);
        }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
