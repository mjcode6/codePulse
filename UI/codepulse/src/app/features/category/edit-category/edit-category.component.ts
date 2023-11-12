import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { __param } from 'tslib';
import { CategoryService } from '../services/CategoryService';
import { Category } from '../models/category.model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy{

id: string | null = null;
paramsSubscription: Subscription | undefined;

category?: Category;




  constructor(private route: ActivatedRoute,
    private categoryService: CategoryService){

  }
  
  ngOnInit(): void {
   this.paramsSubscription =  this.route.paramMap.subscribe({
      next: (params) => {
       this.id =  params.get('id');

      if(this.id){
        // get the data from the api for this category id
        this.categoryService.getCategoryById(this.id)
        .subscribe({
          next: (response) => {
               this.category = response;
          }
        });
      }


      }
    });
  }

  onFormSubmit(): void{
       console.log(this.category);
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
  }

}
