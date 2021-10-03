import {Component} from '@angular/core';
import { navItems } from '../../_nav';
import { AuthenticationService } from '../../services/authentication.service'
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent {
  public sidebarMinimized = false;
  public navItems = navItems;

  constructor(private authservice: AuthenticationService, private route: ActivatedRoute, private router: Router) {

  }

  toggleMinimize(e) {
    this.sidebarMinimized = e;
  }

  logout() {
    debugger;
    this.authservice.logout();
    this.router.navigate(['/login']);
  }
}
