import { NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SvgIconComponent } from './lib/Icon/svg-icon/svg-icon.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SvgIconComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  http = inject(HttpClient)
  users: any;

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/user/list')
    .subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed.')
    })
  }

}
