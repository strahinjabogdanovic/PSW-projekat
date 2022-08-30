import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RecommendAppointmentService } from 'src/app/recommend-appointment.service';
import { UserService } from 'src/app/user.service';
import { BUserDto } from './buser.dto';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  public users: any[];
  public user: BUserDto;

  constructor(private route: ActivatedRoute, private router: Router, private ras: RecommendAppointmentService) { 
    this.users = [];
    this.user = new BUserDto();
  }

  ngOnInit(): void {
    this.ras.GetAllPatients().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.users.push(p);      
      }
    })
  }

  Block(){}
  Unblock(){}

}
