import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/CategoryService';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy{

model: AddCategoryRequest;

private addCategorySubcription?: Subscription;

constructor(private CategoryService: CategoryService){
  this.model = {
    name:'',
    urlHandle: ''
  };
}
 

onFormSubmit(){
  
     this.addCategorySubcription    = this.CategoryService.addCategory(this.model)
.subscribe({
  next: (Response) => {
    console.log('this was sucessfull!');
  },
  error: (error) => {

  }
})


}
ngOnDestroy(): void {
  this.addCategorySubcription?.unsubscribe();
}

}
