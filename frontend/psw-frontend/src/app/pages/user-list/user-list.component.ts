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
  displayedColumns: string[] = ['name', 'surname', 'blocked', 'numOfC', 'block', 'unblock'];
  public users: any[];
  public user: BUserDto;
  public id: any; 
  dataSource = [];

  constructor(private route: ActivatedRoute, private router: Router, private ras: RecommendAppointmentService) { 
    this.users = [];
    this.user = new BUserDto();
  }

  ngOnInit(): void {
    this.ras.GetAllPatients().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.users.push(p);    
        this.dataSource = data;    
      }
    })
  }

  Block(id: number){
    this.ras.BlockUser(id).subscribe((data: any) =>{
      this.ngOnInit();
       alert("User is blocked.")
    });  
  }


  Unblock(id: number){
        this.ras.UnblockUser(id).subscribe((data: any) =>{
          alert("User is no longer blocked.")
          this.ngOnInit();
      });  
  }
}
