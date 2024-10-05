// src/app/components/person-list/person-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { Person } from '../../models/person.model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss']
})
export class PersonListComponent implements OnInit {
  persons: Person[] = [];

  constructor(private personService: PersonService, private router: Router) {}

  ngOnInit(): void {
    this.loadPersons();
  }

  loadPersons(): void {
    this.personService.getPersons().subscribe(data => {
      this.persons = data;
    });
  }

  goToCreatePerson(): void {
    this.router.navigate(['/person-form']);
  }

  deletePerson(id: number): void {
    this.personService.deletePerson(id).subscribe(() => {
      this.loadPersons(); // Recarga la lista después de eliminar
    });
  }

  goToEditPerson(id: number): void {
    this.router.navigate(['/person-form', id]);
  }
}