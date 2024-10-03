// src/app/components/person-form/person-form.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { Person } from '../../models/person.model';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent {
  person: Person = {
  id:0,
  firstName:'',
  lastName:'',
  email:'',
  dateOfBirth: new Date(),
  phoneNumber:'',
  address:''
};

  constructor(private personService: PersonService, private router: Router) {}

  savePerson(): void {
    this.personService.createPerson(this.person).subscribe(() => {
      this.router.navigate(['/persons']);
    });
  }
}