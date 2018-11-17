import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/questions/q_q';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  answer: string;
  defaultString = 'Where is my answer?';

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
    return this.http.post(this.baseUrl + model.problem, model).pipe(
      map((response: any) => {
        const answer = response;
        this.answer = answer.answer;
        // if (answer) {
        // localStorage.setItem('answer', this.answer);
        // }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
