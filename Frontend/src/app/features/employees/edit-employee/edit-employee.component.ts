import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../models/employee.model';
import { EmployeeService } from '../../../services/employee.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss'
})
export class EditEmployeeComponent implements OnInit {

employee:Employee={id:0,name:'',email:'', salary:0};
private apiURL = environment.apiUrl + '/Employee';

constructor(
  private employeeService: EmployeeService,
  private router:Router,
  private route: ActivatedRoute
){}
 ngOnInit():void{
 const id = Number(this.route.snapshot.paramMap.get('id'));
 this.loadEmployee(id);
}

loadEmployee(id:number):void{
 this.employeeService.getEmployeeById(id).subscribe({
  next:(data) => this.employee= data,
  error:(err:any) => console.error("Error loading employee ", err)  
});
}

updateEmployee():void{
  this.employeeService.updateEmployee(this.employee).subscribe({
    next:() => this.router.navigate(['/employees']),
    error:(err: any) => console.error("Error updating employee ", err)
  });
}


}