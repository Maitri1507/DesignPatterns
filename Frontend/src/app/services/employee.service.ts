import {Injectable} from '@angular/core'; // I want to make a class that Angular can use anywhere
import {Employee} from '../models/employee.model';
import {environment} from '../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';


@Injectable({
    providedIn: 'root' // please create one single copy of this servuce and share it everywhere
})

// service: a small office that will handle everything
export class EmployeeService {

    private apiURL = environment.apiUrl + '/employee'; // this is the base URL for the API
    constructor(private http: HttpClient) {}

    getEmployees() : Observable<Employee[]> {
        return this.http.get<Employee[]>(this.apiURL);
    }
    getEmployeeById (id : number): Observable<Employee>{
        return this.http.get<Employee>(this.apiURL + '/' + id);
    }
  
    addEmployee(employee: Employee):Observable<Employee>{
        return this.http.post<Employee>(this.apiURL, employee);
    }

    updateEmployee(employee: Employee): Observable<Employee>{
        return this.http.put<Employee>(this.apiURL + '/' + employee.id, employee);
    }

    deleteEmployee(id: number): Observable<void>{
        return this.http.delete<void>(this.apiURL + '/' + id);
    }


}