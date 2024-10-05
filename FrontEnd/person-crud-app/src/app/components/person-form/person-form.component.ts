// src/app/components/person-form/person-form.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { Person } from '../../models/person.model';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit{
  person: Person = {
  id:0,
  firstName:'',
  lastName:'',
  email:'',
  dateOfBirth: new Date(),
  phoneNumber:'',
  address:''
};
isEditMode = false;
  constructor(
    private personService: PersonService,
    private router: Router,
    private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
      this.route.params.subscribe(params => {
        const id = params['id'];
        if (id) {
          this.isEditMode = true;
          this.personService.getPersons().subscribe(persons => {
            this.person = persons.find(p => p.id === +id) || this.person;
          });
        }
      });
    }

  savePerson(): void {
    if (this.isEditMode) {
      this.personService.updatePerson(this.person).subscribe(() => {
        this.router.navigate(['/persons']);
      });
    } else {
    this.personService.createPerson(this.person).subscribe(() => {
      this.router.navigate(['/persons']);
    });
  }
}
}