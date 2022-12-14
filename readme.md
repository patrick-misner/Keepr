
<h1 align="center"><project-name> Keeper</h1>

<p align="center"><project-description>Users can create posts with a photo called a "Keep" and create collections called a "Vault" that can store keeps created by any user. The Vaults can be marked as private on creation so only the logged in user can see the Vault. When a logged-in user clicks on Keep, they have the ability to add the keep to a Vault. The front-end and back-end will not allow a keep to be added to the same vault twice. The back-end is a .NET C# API server using the MVC pattern and dapper as the ORM to query MySQL. The front-end was written with Vue.js, a reactive javascript framework.</p>

# Links

- [Repo](https://github.com/patrick-misner/Keepr "Keeper Repo")

- [Live (Heroku, may take some time to load)](https://keeper-pm.herokuapp.com/ "Live View")




## Built With


- JavaScript
- Vue3
- DotNet MVC
- C#
- Dapper
- MySQL
- HTML
- CSS

## Future Updates

- [x] User cannot add keep to the same vault twice front-end / back-end
- [ ] tags field

## Author

**Patrick Misner**

- [Profile](https://github.com/patrick-misner "Patrick Misner")
- [Email](mailto:misner.patrick@gmail.com?subject=Hi "Hi!")
- [Website](https://patrick-misner.github.io "Patrick Misner")

- - -

# Screenshots

## Home Page

![Home Page](/Keepr.client/src/assets/img/homepage.png "Home Page")




## Adding a Vault

Log in and go to profile

![](/Keepr.client/src/assets/img/myprofile.png)

![vault](/Keepr.client/src/assets/img/addvault.png)

Modal triggers

![vault](/Keepr.client/src/assets/img/privatevault.png)

Sweet Alert pop notification

![](/Keepr.client/src/assets/img/Pop-notify.png)
- - -
## Adding a Keep

Log in and go to profile

![](/Keepr.client/src/assets/img/myprofile.png)

![vault](/Keepr.client/src/assets/img/addkeep.png)

Modal triggers

![vault](/Keepr.client/src/assets/img/keepform.png)

Sweet Alert pop notification

![](/Keepr.client/src/assets/img/keep-pop.png)

- - -
## Adding a Keep to a Vault

Click on a Keep on homepage or profile page.

![](/Keepr.client/src/assets/img/addkeeptovault.png)

![vault](/Keepr.client/src/assets/img/addkeeptovaultpop.png)

You cannot add a specific keep to your vault twice, selection is disabled.

![vault](/Keepr.client/src/assets/img/addkeeptovaultdisable.png)


---

## Private Vaults

On your profile page when logged in you have access to private vaults

![](/Keepr.client/src/assets/img/privatevaultloggedin.png)

The vault page shows the keeps contained

![vault](/Keepr.client/src/assets/img/privatevaultpage.png)

If you are logged out or a different user the private vault is not accessible.

![vault](/Keepr.client/src/assets/img/privatevaultloggedout.png)


## Delete Keep

When viewing a keep that you own, the ellipses has a drop down with a delete option

![](/Keepr.client/src/assets/img/deletekeep.png)

