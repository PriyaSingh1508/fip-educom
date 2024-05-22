import { HttpHeaders } from "@angular/common/http";

interface IDictionary {
     add(key:string,value:any):void;
    remove(key:string):void;
    keys():string[];
    values():any[];
    createHttpHeadersFromDictionary(dictionary:IDictionary):HttpHeaders;
}
export class Dictionary implements IDictionary{
    
    _keys:string[]=[];
    _values:any[]=[];
    
    keys(): string[] {
        return this._keys;
    }

    values(): any[] {
        return this._values;
    }
    
    add(key: string, value: any): void {
        
        const index=this._keys.indexOf(key);
        if ( index=== -1) {
            // this[key]==value;
            this._keys.push(key);
            this._values.push(value);
        }else{
            console.log(`${key} with same name already exists, so updating value`);
            this._values[index]=value;
        }
    }
    remove(key: string): void {
        const index = this._keys.indexOf(key);
        if (index !== -1) {
            this._keys.splice(index, 1);
            this._values.splice(index, 1);
        } else {
            console.log(`${key}Key not found.`);
        }
    }
    [key:string]:any;

    


    
    constructor() {
       
        //Implementation for indexer
        return new Proxy(this, {
            get(target, prop, receiver) {
                if (typeof prop === 'string' && target._keys.includes(prop)) {
                    return target._values[target._keys.indexOf(prop)];
                } else {
                    return Reflect.get(target, prop, receiver);
                }
            },
            set(target, prop, value, receiver) {
                if (typeof prop === 'string') {
                    const index = target._keys.indexOf(prop);
                    if (index === -1) {
                        target.add(prop, value);
                    } else {
                        target._values[index] = value;
                    }
                } else {
                    return Reflect.set(target, prop, value, receiver);
                }
                return true;
            }
        });
    }
    
    createHttpHeadersFromDictionary(dictionary:any):HttpHeaders{
        let headers=new HttpHeaders();
      if(dictionary){   
        dictionary.keys().forEach((key: string) => {
        headers=headers.append(key, dictionary[key].toString());
          console.log(key);
      });
      console.log(headers);
      }
      return headers;      
    } 
    
    AddHeader(key:string,value:any,header?:HttpHeaders):HttpHeaders{
        let headers=new HttpHeaders();
       if(header){
        headers=header;
       }
       if(key&&value!=null){
        headers=headers.append(key, value.toString());
       }
       return headers;

    }
  
    
}
