import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { StudentService } from '../student.service';
import { Observable, debounceTime, map, startWith } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { City, Country, ResponseModel, State, StudentDetail } from 'src/app/model';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})

export class AddStudentComponent implements OnInit {
  
  autoIndex: number=0;
  addressArray!:FormArray<any>;
  filteroptions!:Observable<City[]>;
  
  
  data:StudentDetail = { 
    id:0,
    firstName: '',
    lastName: '',
    email: '',
    mobileNo: '',
    password: '',
    dob: new Date,
    gender: 'Male', 
    policyAgreement: false,
    addresses: [],
    userRole:''
  }
  filteredCities:City[]=[];
  addnew:boolean=true;

 
    

  maxDate:any;
  registerForm:FormGroup;
  
  gender:string[]=['Male','Female'];
  states: State[] = [];
  countries: Country[] = [];
  cities!: City[];

  ngOnInit(): void {
    this.getCountries();  
    this.addDebounceTime();
    let id=this.router.paramMap.subscribe((params)=>{
      const id=params.get('id');
      if(id){
        this.addnew=false;
        let users=this.service.getDataLocal().filter(item=>item.id.toString()==id)
        this.data=users[0];
      }
    })

   
    
    
   
  }


 constructor(private service:StudentService,private fb:FormBuilder,private router:ActivatedRoute) {
  this.maxDate=new Date;
  this.registerForm = fb.group({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    mobileNo: new FormControl('', [Validators.required, Validators.pattern('[0-9]*')]),
    password: new FormControl('', [Validators.required,Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$')]),
    confirmPassword: new FormControl('', [Validators.required,this.passwordMatchValidator()]),
    dob: new FormControl(''),
    gender:new FormControl(''),
    policyAgreement: new FormControl(false),
    addresses: new FormArray([
      new FormGroup({
        address:new FormControl(''),
      zipcode:new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      country: new FormControl('')

      })
    ]) 

    


  }
  );


 }

  onUpdate(){
    
  }
  getCountries() {
    this.service.getData<Country[]>("country.json").subscribe((data) => {
      this.countries = data;
    }, (error) => {
      console.log("error");
    });
  }
  public selectCountry(country: any) {
    if (!country) {
      this.registerForm.controls['state'].setValue('');
      this.registerForm.controls['city'].setValue('');
      this.states = [];
      this.cities = [];
      return;
    }
  
    const countryId = parseInt(country);
    this.service.getData<State[]>("state.json").subscribe((data) => {
      this.states = data.filter(item => item.countryId === countryId);
      
    }, (error) => {
      console.log("error");
    });
  }
 autochange(index:any){
  this.addressArray= this.registerForm.get('addresses') as FormArray;
  const addobj=this.addressArray.at(index) as FormGroup
  const _control=addobj.get('city') as FormControl
  this.filteroptions=_control.valueChanges.pipe( startWith(''),
  map(value => this.filterCities(_control.value||''))
);



 }

  addAddress() {
    const control = new FormGroup({
      address:new FormControl(''),
      zipcode:new FormControl(''),
      city: new FormControl(''),
      state: new FormControl(''),
      country: new FormControl('')
    });
    (this.registerForm.get('addresses') as FormArray).push(control);
   
  }
  deleteAddress(index:any){
    const control=<FormArray>this.registerForm.controls['addresses'];
    control.removeAt(index);
  }
  public selectState(state: any) {
    if (!state) {
      this.registerForm.controls['city'].setValue('');
      this.cities = [];
     
      return;
    }
    
    const stateId = parseInt(state);
    this.service.getData<City[]>("city.json").subscribe((data) => {
      this.cities = data.filter(item => item.state_id === stateId);
      this.filteredCities=this.cities;
      
    }, (error) => {
      console.log("error");
    });
    
  }
  selectCity(index:any){
    this.addressArray= this.registerForm.get('addresses') as FormArray;
    const addobj=this.addressArray.at(index) as FormGroup
    const _control=addobj.get('state') as FormControl
    this.service.getData<City[]>("city.json").subscribe((data) => {
      this.cities = data.filter(item => item.state_id === _control.value);
      this.filteredCities=this.cities;
      
    }, (error) => {
      console.log("error");
    });

  }
  filterCities(city:string):City[]{
   
    const value=city.toLowerCase();
    return this.cities.filter(data=>data.cityName.toLowerCase().includes(value));

  }
 
  addDebounceTime(){
    
    Object.keys(this.registerForm.controls).forEach(controlName => {
      this.registerForm.get(controlName)!.valueChanges
        .pipe(
          debounceTime(300) 
        )
        .subscribe((value: any) => {
         
          console.log(`${controlName} value changed:`, value);
        
        });
    });
    
  }
  
  
 
  onRegister(){

    console.log(this.registerForm.value);
    if(this.registerForm.valid){
      let address:any[]=[];
      (this.registerForm.get('addresses')as FormArray).controls.forEach(item=>address.push(item.value));

      
      
      let student:StudentDetail ={
        id:0,
        firstName:this.FirstName.value,
        lastName:this.LastName.value,
        email :this.Email.value,
        mobileNo:this.MobileNo.value,
        password:this.Password.value,
        userRole:'Student',
        addresses:address,
        gender:this.Gender.value,
        dob:this.Dob.value,
        policyAgreement: this.PolicyAgreement.value

    
      }
      console.log(student);
      // this.service.saveStudent(student);
      this.service.postData<ResponseModel<string>>("Student/AddStudent",student).subscribe({
        next:(res)=>{
          console.log (res);
          this.registerForm.reset();
          
          // this.router.navigate(['/dashboard']);
        
        },error:(err)=>{
          console.log(err);
          
  
        }
      });
      
    
    }

  }
  get PolicyAgreement():FormControl{
    return this.registerForm.get('policyAgreement')as FormControl
  }
  get FirstName():FormControl{

    return this.registerForm.get('firstName') as FormControl;
  }
  get LastName():FormControl{

    return this.registerForm.get('lastName') as FormControl;
  }
  
  
  get Email():FormControl{
  
    return this.registerForm.get('email') as FormControl;
  
  }
  get MobileNo():FormControl{
  
    return this.registerForm.get('mobileNo') as FormControl;
  
  }
  
  get Password():FormControl{
  
    return this.registerForm.get('password') as FormControl;
  
  }
  
  get ConfirmPassword():FormControl{
  
    return this.registerForm.get('confirmPassword') as FormControl;
  
  }
  get Dob():FormControl{
  
    return this.registerForm.get('dob') as FormControl;
  
  }
  get Country():FormControl{
  
    return this.registerForm.get('country') as FormControl;
  
  }
  get State():FormControl{
  
    return this.registerForm.get('state') as FormControl;
  
  }
  get addressControls() { return (this.registerForm.get('addresses') as FormArray).controls; }
  get Gender():FormControl{
    return this.registerForm.get('gender') as FormControl;
  }
  
  passwordMatchValidator():ValidatorFn{
    return (control:AbstractControl): {[key:string]:any} |null =>{
      const password=control.root.get('password')?.value;
      const confirmPassword=control.value;
      return password===confirmPassword ? null :{'passwordMismatch':true};
    
    }
  }
  

}
