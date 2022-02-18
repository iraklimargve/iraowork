import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  login() {
    var user = (<HTMLInputElement>document.getElementById('usernameid')).value;
    var password = (<HTMLInputElement>document.getElementById('passwordid')).value;
    this.http.post(this.baseUrl + 'users/authenticate',
      {
        'Name': user,
        'Password': password
      }).subscribe(result => {
        console.log('success');
      });
  }


}
