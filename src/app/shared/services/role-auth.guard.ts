import { inject } from '@angular/core';
import { CanActivateFn, Router,ActivatedRouteSnapshot,RouterStateSnapshot } from '@angular/router';
import { TokenHandlerService } from './token-handler.service';

export const RoleAuthGuard: CanActivateFn = (route:ActivatedRouteSnapshot, state:RouterStateSnapshot) => {

  const _tokenHandler= inject(TokenHandlerService);
  const router:Router= inject(Router);
  const data = _tokenHandler.getToken();
  if (data) {
    const role = data.role;
    if (role === 'Admin' && state.url.includes('admin-dashboard')) {
      return true;
    } else if (role === 'Teacher' && state.url.includes('teacher-dashboard')) {
      return true;
    } else if (role === 'Student' && state.url.includes('student-dashboard')) {
      return true;
    }
  }
  router.navigate(['/login']);
  return false;
};
