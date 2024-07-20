import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../shared/student.service';
import { Subscription } from 'rxjs';
import { Student } from '../../shared/student.model';

@Component({
  selector: 'app-student-detail-form',
  templateUrl: './student-detail-form.component.html',
  styles: ``
})


export class StudentDetailFormComponent implements OnInit{
  
  subscription = new Subscription();
  studentForm!: FormGroup;
  

  constructor(private studentService: StudentService,
    private formBuilder: FormBuilder){
    
  }

  ngOnInit(): void {
    this.createForm();
  }

  createForm():void{
    this.studentForm = this.formBuilder.group({
      firstName: new FormControl<string>('', {validators: [Validators.required, Validators.minLength(2), Validators.maxLength(30)]}),
      lastName: new FormControl<string>('', {validators: [Validators.required]}),
      birthDate: new FormControl<Date>(new Date, {validators: [Validators.required]}),
      email: new FormControl<string>('', {validators: [Validators.email]}),
      phoneNumber: new FormControl<string>('', {validators: [Validators.required]}),
    });
  }

  save(): void{
    const student = {
      firstName: this.studentForm.value.firstName,
      lastName: this.studentForm.value.lastName,
      birthDate: this.studentForm.value.birthDate,
      email: this.studentForm.value.email,
      phoneNumber: this.studentForm.value.phoneNumber
    } as Student;

    this.subscription.add(
      this.studentService.save(student)
        .subscribe({
          next: data => {
           
          },
          error: err => {}
        })
    );
  }

}
