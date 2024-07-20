import { Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, output, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { StudentService } from '../../shared/student.service';
import { Subscription } from 'rxjs';
import { Student } from '../../shared/student.model';


@Component({
  selector: 'app-student-detail-form',
  templateUrl: './student-detail-form.component.html',
  styles: ``
})


export class StudentDetailFormComponent implements OnInit, OnDestroy, OnChanges{
  
  subscription = new Subscription();
  studentForm!: FormGroup;
  studentAdded = output<any>();
  studentUpdated = output<any>();
  @Input() selectedStudent!: Student;

  constructor(private studentService: StudentService,
    private formBuilder: FormBuilder){
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    this.createForm();
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.selectedStudent = {} as Student;
    this.createForm();
  }

  createForm():void{
    this.studentForm = this.formBuilder.group({
      firstName: new FormControl<string>(this.selectedStudent ? this.selectedStudent.firstName : '', {validators: [Validators.required, Validators.minLength(2), Validators.maxLength(30)]}),
      lastName: new FormControl<string>(this.selectedStudent ? this.selectedStudent.lastName : '', {validators: [Validators.required]}),
      birthDate: new FormControl<Date>(this.selectedStudent ? this.selectedStudent.birthDate : new Date, {validators: [Validators.required]}),
      email: new FormControl<string>(this.selectedStudent ? this.selectedStudent.email: '', {validators: [Validators.email]}),
      phoneNumber: new FormControl<string>(this.selectedStudent ? this.selectedStudent.phoneNumber : '', {validators: [Validators.required]}),
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

    if(this.selectedStudent.id != null){
      student.id = this.selectedStudent.id;
      this.updateStudent(student);
    }else{
      this.addStudent(student);
    }    
  }

  addStudent(student: Student): void{
  
    this.subscription.add(
      this.studentService.save(student)
        .subscribe({
          next: data => {
           this.studentAdded.emit(data);
          },
          error: err => {}
        })
    );
  }

  updateStudent(student: Student): void{
    this.subscription.add(
      this.studentService.update(student)
        .subscribe({
          next: data => {
            this.studentUpdated.emit(data);
          },
          error: err => {}
        })
    );
  }

  clear(): void{
    this.selectedStudent = {} as Student;
    this.createForm();
  }

}
