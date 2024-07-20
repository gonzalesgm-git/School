import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { StudentService } from '../shared/student.service';
import { Student } from '../shared/student.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styles: ``
})
export class StudentDetailsComponent implements OnInit, OnDestroy {

  studentList: Student[] = [];
  subscription = new Subscription();
  selectedStudent!: Student;
  constructor(private studentService: StudentService){
  }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void{
    this.subscription.add(
      this.studentService.list()
      .subscribe({
        next: data => {
          console.log(data);
          this.studentList = data as Student[];
        },
        error: err => {console.log(err)}
        
      })
    );
  }

  studentAddedEvent(data:any):void{
    this.refreshList();
    this.clear();
  }

  studentUpdatedEvent(data:any): void{
    this.refreshList();
  }

  studentSelected(student:Student): void{
    this.selectedStudent = student;
  }

  deleteStudent(student: Student): void{
    this.subscription.add(
      this.studentService.delete(student)
      .subscribe({
        next: data => {
          console.log(data);
          if(data.success){
            this.refreshList();
            this.clear();
            
          }
        },
        error: err => {}
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  clear(): void{
    this.selectedStudent = {} as Student;
  }
}
