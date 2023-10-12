import { Component } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/CategoryService';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

model: AddCategoryRequest;

constructor(private CategoryService: CategoryService){
  this.model = {
    name:'',
    urlHandle: ''
  };
}

onFormSubmit(){
  
this.CategoryService.addCategory(this.model)
.subscribe({
  next: (Response) => {
    console.log('this was sucessfull!');
  },
  error: (error) => {

  }
})


}


}
