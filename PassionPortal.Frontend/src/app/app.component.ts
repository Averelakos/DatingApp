import { HttpClient} from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SvgIconComponent } from './shared/lib/icon-library/svg-icon/svg-icon.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SvgIconComponent, AuthLayoutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  http = inject(HttpClient)
  users: any;

  ngOnInit(): void {
    // this.http.get('https://localhost:5001/api/user/list')
    // .subscribe({
    //   next: response => this.users = response,
    //   error: error => console.log(error),
    //   complete: () => console.log('Request has completed.')
    // })
  }

}
