import { HttpStatusCode } from "@angular/common/http";

export interface TutorialsLibrary {
    title: string;
    technologies: Technology[];
  }
   
  interface Technology {
    name: string;
    imageUrl: string;
    link: string;
  }
  export interface Tools{
    toolId:number;
    name: string;
    imageUrl:string;
  }
  export interface Feedbacks{
    feedbackId:number,
      name:string,
      course:string,
      feedback:string;
  }

 
  interface TutorialListItem{
    itemId:number,
    title:string
  }
  interface CategoryItem{
    categoryId:number,
    categoryName:string,
    categoryItem:TutorialListItem[],
  }
  export interface TutorialCategory{
    name:string,
    image:string,
    item:CategoryItem[]
  }
  export interface TutorialItem{
    categoryId:number,
    itemId:number,
    heading:string,
    text:string,
  }
  export interface TopCategory{
    id:number,
    name:string,
    imageUrl:string,
    link:string,
  }
  export interface LibraryListItems{
    name:string,
    url:string,
  }
  export interface LibraryList{
    id:number,
    categoryName:string,
    items:LibraryListItems[]
  }
  export interface CategoryContent{
    id:number,
    categoryId:number,
    text:string
  }

//articles module
  export interface Category {
  category: string;
  categoryList: ArticleCategoryItem[];
}

export interface ArticleCategoryItem {
  title: string;
  categorycontent: Article[];
}

export interface Article {
  title:string;
  description: string;
  author: string;
  modifiedDate: string;
}


export interface Country{
  
    id: number,
    sortname: string,
    name: string,
    phonecode: number
   
}

export interface State{
     id: number,
     countryId: number,
     statename: string
}

export interface City{
    id: number,
    cityName: string,
    state_id: number
}


export interface User{
  id:number
  firstName:string,
  lastName:string,
  email:string,
  password:string,
  mobileNumber:string,
  dateOfBirth: Date,
  gender: string, 
  acceptTerms: boolean,
  addresses: any[],
  role:string


}
export interface StudentDetail{
  id:number
  firstName:string,
  lastName:string,
  email:string,
  password:string,
  mobileNo:string,
  dob: Date,
  gender: string, 
  policyAgreement: boolean,
  addresses: any[],
  userRole:string


}
export interface Login{
  email:string,
  password:string
}
export interface TutorialOption{
  id:number,
tutorialName:string,
imageUrl:string,
tutorId:number,
tutorialCategoryItems:TutorialCategoryItem[]
}
export interface TutorialCategoryItem{
  subCategoryName:string,
  categoryId:number,
  tutorialItems:TutorialItems[]
}
export interface TutorialItems{
  subCategoryId:number,
  title:string,
  description:string,
}
export interface TutorialRegister{
  technologyId:number,
  tutorialCategoryId: number,
  topic: string,
  description: string
}
export interface TechnologyDTO{
  id:number,
technologyName:string,
imageUrl:string,
isPublished:boolean

}
export interface TutorialCategoryDTO{
  id:number,
  tutorialCategoryName:string
}
export interface GetTechnologyTutorialDTO{
  id: number,
  technologyName: string,
  imageUrl: string,
  isPublished:boolean,
  categories: any[]
}

export interface GetAllTutorials{
  id:number,
  technologyId: number,
  tutorialCategoryId: number,
  topic: string,
  description:string,
  isPublished:boolean
}
export interface TechnologyTutorialCategory{
  TechnologyId :number
TutorialCategoryName:string[]
}
export interface TutorialCategoriesDTO{
  id:number
  tutorialCategoryName : string 
  technologyId:number;
  technologyName:string,
  isPublished:boolean
}

export interface FooterItem{
  id:number,
  title:string,
  items:footerNavItem[]
}
export interface footerNavItem{
  itemId:number,
  name:string,
}

export interface RequestModel{
 id: number|null,
itemsPerPage:number;
 pageNo:number 
}
export interface ResponseModel<T>{
  status:HttpStatusCode,
  data:T,
  totalRecords:number,
  message:string,
  isSuccess:boolean

}
