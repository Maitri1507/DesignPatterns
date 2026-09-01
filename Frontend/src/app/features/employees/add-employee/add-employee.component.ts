import { Component } from '@angular/core';
import { Employee } from '../../../models/employee.model';
import { EmployeeService } from '../../../services/employee.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss'
})
export class AddEmployeeComponent  {

  employee:Employee={id:0,name:'',email:'', salary:0};
 
  constructor(
    private employeeService: EmployeeService, 
    private router: Router  
  ){}

  addEmployee(): void {
    this.employeeService.addEmployee(this.employee).subscribe({
      next: () => this.router.navigate(['/employees']),
      error: (err) => console.error("Error adding employee ", err)
    });
  }
}
