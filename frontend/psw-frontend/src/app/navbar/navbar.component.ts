import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  
  public role: any;
  public token: string = '';

  constructor(private router: Router) { }
  ngOnInit(): void {
    this.role = localStorage.getItem('Role');
  }

  LogOut(){
    this.router.navigate(['/login']);
    localStorage.setItem('jwtToken', this.token);
    localStorage.setItem('Role', this.token);
    //localStorage.clear();
  }

}
