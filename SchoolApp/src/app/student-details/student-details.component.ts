import { Component, OnDestroy, OnInit } from '@angular/core';
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
  constructor(private studentService: StudentService){
  }

  ngOnInit(): void {
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

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
