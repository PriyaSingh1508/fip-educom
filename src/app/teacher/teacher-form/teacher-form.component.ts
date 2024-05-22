import { Component } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray, ValidatorFn, AbstractControl } from '@angular/forms';
import { TeacherService } from '../teacher.service';
import { City, Country, State} from 'src/app/model';
import { Observable, map, startWith } from 'rxjs';


@Component({
  selector: 'app-teacher-form',
  templateUrl: './teacher-form.component.html',
  styleUrls: ['./teacher-form.component.css']
})
export class TeacherFormComponent {
 
  public countries: Country[] = [];
  public states: State[] = [];
  public cityList:City[]=[];

  teacherLoginForm: FormGroup;
  minDate = new Date(2000, 0, 1);
  maxDate = new Date(2024, 0, 1);

  constructor(private fb: FormBuilder, private teacherService: TeacherService) {    
    this.teacherLoginForm = fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      mobileNumber: ['', [Validators.required,Validators.pattern('[- +()0-9]{6,}')]],
      email: ['', [Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')]],
      password: ['', Validators.required],
      cPassword: ['', [Validators.required, this.matchPasswordValidator()]], // Add custom validator
      gender: ['male'],
      dob: [''],     
      policyAgreement: ['true'],
      addresses: fb.array([])
    });
  }
   
  ngOnInit(): void {
    this.getCountries();
    this.addTempAdd();
  }        

  options: City[] = [];
  filteredOptions: Observable<City[]>[] = [];
  
  private getCountries() {
    this.teacherService.getData<Country[]>("country.json").subscribe(
      (data) => {
        this.countries = data;
      },
      (error) => {
        console.log('Something went wrong: ', error);
      }
    );
  }
  
  displayFn(city: string): string {
   // return city && city.cityName ? city.cityName : '';
   return city;
  }
  
  private _filter(name: string): City[] {
    const filterValue = name.toLowerCase();
    return this.options.filter(option => option.cityName.toLowerCase().includes(filterValue));
  }
  
  public selectCountry(id: number, index: number) {
    this.teacherService.getData<State[]>("state.json").subscribe(
      (response) => {
        const states = response.filter(item => item.countryId === id);
        const addressGroup = (this.teacherLoginForm.get('addresses') as FormArray).at(index) as FormGroup;
        addressGroup.get('states')?.setValue(states);
      },
      (error) => {
        console.log('Error fetching states:', error);
      }
    );
  }
 
  public selectState(stateId: number, index: number) {
    this.teacherService.getData<City[]>("city.json").subscribe(
      (response) => {
        const cities = response.filter(item => item.state_id === stateId);
        const addressGroup = (this.teacherLoginForm.get('addresses') as FormArray).at(index) as FormGroup;
        addressGroup.get('cities')?.setValue(cities);
        this.options = addressGroup.get('cities')?.value || [];
        const cityValueChanges = addressGroup.get('city')?.valueChanges;
        if (cityValueChanges) {
          this.filteredOptions[index] = cityValueChanges.pipe(
            startWith<string | City>(''),
            map(value => typeof value === 'string' ? value : value.cityName),
            map(name => name ? this._filter(name) : this.options.slice())
          );
        }
      },
      (error) => {
        console.log('Error fetching cities:', error);
      }
    );
  }
 
  get addresses() {
    return this.teacherLoginForm.controls["addresses"] as FormArray;
  }
  
  addTempAdd() {
    const tempAddForm = this.fb.group({
      street: ['', [Validators.maxLength(30)]],
      zipCode: ['', [Validators.maxLength(6)]],
      country: [''],
      state: [''],
      city: [''],
      states: [[]], // Array to hold states for each address
      cities: [[]]  // Array to hold cities for each address
    });
 
    // Subscribe to changes in country and state for each address
    tempAddForm.get('country')?.valueChanges.subscribe((countryId:any) => {
      if (countryId != null) {
        const index = this.addresses.controls.indexOf(tempAddForm);
        this.selectCountry(countryId, index);
      }
    });
 
    tempAddForm.get('state')?.valueChanges.subscribe((stateId:any) => {
      if (stateId != null) {
        const index = this.addresses.controls.indexOf(tempAddForm);
        this.selectState(stateId, index);
      }
    });
  
    this.addresses.push(tempAddForm);
  }
  onSubmit() {
    console.log(this.teacherLoginForm.value);
  }

  // Custom validator function to check if password and confirm password match
  matchPasswordValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const password = control.root.get('password')?.value;
      const confirmPassword = control.value;
      return password === confirmPassword ? null : { 'passwordMismatch': true };
    };
  }


  
}
