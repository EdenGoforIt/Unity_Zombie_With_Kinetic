<?php
Route::get('/', function () {
    return redirect('/admin/home');
});

// Authentication Routes...
$this->get('login', 'Auth\LoginController@showLoginForm')->name('auth.login');
$this->post('login', 'Auth\LoginController@login')->name('auth.login');
$this->post('logout', 'Auth\LoginController@logout')->name('auth.logout');

// Change Password Routes...
$this->get('change_password', 'Auth\ChangePasswordController@showChangePasswordForm')->name('auth.change_password');
$this->patch('change_password', 'Auth\ChangePasswordController@changePassword')->name('auth.change_password');

// Password Reset Routes...
$this->get('password/reset', 'Auth\ForgotPasswordController@showLinkRequestForm')->name('auth.password.reset');
$this->post('password/email', 'Auth\ForgotPasswordController@sendResetLinkEmail')->name('auth.password.reset');
$this->get('password/reset/{token}', 'Auth\ResetPasswordController@showResetForm')->name('password.reset');
$this->post('password/reset', 'Auth\ResetPasswordController@reset')->name('auth.password.reset');




Route::group(['middleware' => ['auth'], 'prefix' => 'admin', 'as' => 'admin.'], function () {
    Route::get('/home', 'HomeController@index');

    Route::resource('roles', 'Admin\RolesController');
    Route::post('roles_mass_destroy', ['uses' => 'Admin\RolesController@massDestroy', 'as' => 'roles.mass_destroy']);
    Route::resource('users', 'Admin\UsersController');
    Route::post('users_mass_destroy', ['uses' => 'Admin\UsersController@massDestroy', 'as' => 'users.mass_destroy']);

    Route::resource('categories', 'Admin\CategoryController');
    Route::post('categories_mass_destroy', ['uses' => 'Admin\CategoryController@massDestroy', 'as' => 'categories.mass_destroy']);
    Route::post('categories_restore/{id}', ['uses' => 'Admin\CategoryController@restore', 'as' => 'categories.restore']);
    Route::delete('categories_perma_del/{id}', ['uses' => 'Admin\CategoryController@perma_del', 'as' => 'categories.perma_del']);

    Route::resource('countries', 'Admin\CountriesController');
    Route::resource('agencies', 'AgenciesController');
    Route::post('agencies_mass_destroy', ['uses' => 'AgenciesController@massDestroy', 'as' => 'agencies.mass_destroy']);
    Route::post('agencies_restore/{id}', ['uses' => 'AgenciesController@restore', 'as' => 'agencies.restore']);
    Route::delete('agencies_perma_del/{id}', ['uses' => 'AgenciesController@perma_del', 'as' => 'agencies.perma_del']);




    Route::resource('companies', 'CompaniesController');
    Route::post('companies_mass_destroy', ['uses' => 'CompaniesController@massDestroy', 'as' => 'companies.mass_destroy']);
    Route::post('companies_restore/{id}', ['uses' => 'CompaniesController@restore', 'as' => 'companies.restore']);
    Route::delete('companies_perma_del/{id}', ['uses' => 'CompaniesController@perma_del', 'as' => 'companies.perma_del']);





    Route::resource('checksheets', 'ChecksheetsController');
    Route::post('checksheets_mass_destroy', ['uses' => 'ChecksheetsController@massDestroy', 'as' => 'checksheets.mass_destroy']);
    Route::post('checksheets_restore/{id}', ['uses' => 'ChecksheetsController@restore', 'as' => 'checksheets.restore']);
    Route::delete('checksheets_perma_del/{id}', ['uses' => 'ChecksheetsController@perma_del', 'as' => 'checksheets.perma_del']);



    Route::resource('housekeepers', 'HousekeepersController');

    Route::post('housekeepers_mass_destroy', ['uses' => 'HousekeepersController@massDestroy', 'as' => 'housekeepers.mass_destroy']);
    Route::post('housekeepers_restore/{id}', ['uses' => 'HousekeepersController@restore', 'as' => 'housekeepers.restore']);
    Route::delete('housekeepers_perma_del/{id}', ['uses' => 'HousekeepersController@perma_del', 'as' => 'housekeepers.perma_del']);



    Route::resource('payments', 'PaymentsController');
    Route::post('payments_mass_destroy', ['uses' => 'PaymentsController@massDestroy', 'as' => 'payments.mass_destroy']);
    Route::post('payments_restore/{id}', ['uses' => 'PaymentsController@restore', 'as' => 'payments.restore']);
    Route::delete('payments_perma_del/{id}', ['uses' => 'PaymentsController@perma_del', 'as' => 'payments.perma_del']);



    Route::get('contact', 'ContactController@create')->name('contact.create');
    Route::post('contact', 'ContactController@store')->name('contact.store');


    Route::post('countries_mass_destroy', ['uses' => 'Admin\CountriesController@massDestroy', 'as' => 'countries.mass_destroy']);
    Route::post('countries_restore/{id}', ['uses' => 'Admin\CountriesController@restore', 'as' => 'countries.restore']);
    Route::delete('countries_perma_del/{id}', ['uses' => 'Admin\CountriesController@perma_del', 'as' => 'countries.perma_del']);
    Route::resource('customers', 'Admin\CustomersController');
    Route::post('customers_mass_destroy', ['uses' => 'Admin\CustomersController@massDestroy', 'as' => 'customers.mass_destroy']);
    Route::post('customers_restore/{id}', ['uses' => 'Admin\CustomersController@restore', 'as' => 'customers.restore']);
    Route::delete('customers_perma_del/{id}', ['uses' => 'Admin\CustomersController@perma_del', 'as' => 'customers.perma_del']);
    Route::resource('rooms', 'Admin\RoomsController');
    Route::post('rooms_mass_destroy', ['uses' => 'Admin\RoomsController@massDestroy', 'as' => 'rooms.mass_destroy']);
    Route::post('rooms_restore/{id}', ['uses' => 'Admin\RoomsController@restore', 'as' => 'rooms.restore']);
    Route::delete('rooms_perma_del/{id}', ['uses' => 'Admin\RoomsController@perma_del', 'as' => 'rooms.perma_del']);
    Route::resource('bookings', 'Admin\BookingsController', ['except' => 'bookings.create']);
    Route::get('bookings/create/', ['as' => 'bookings.create', 'uses' => 'Admin\BookingsController@create']);
    Route::post('bookings_mass_destroy', ['uses' => 'Admin\BookingsController@massDestroy', 'as' => 'bookings.mass_destroy']);
    Route::post('bookings_restore/{id}', ['uses' => 'Admin\BookingsController@restore', 'as' => 'bookings.restore']);
    Route::delete('bookings_perma_del/{id}', ['uses' => 'Admin\BookingsController@perma_del', 'as' => 'bookings.perma_del']);
    //Route::resource('/find_rooms', 'Admin\FindRoomsController', ['except' => 'create']);
    Route::get('/find_rooms', 'Admin\FindRoomsController@index')->name('find_rooms.index');
    Route::post('/find_rooms', 'Admin\FindRoomsController@index');
    Route::resource('agencies', 'AgenciesController');
    /*Route::get('/bookings/create/', [
        'as' => 'find_rooms.create',
        'uses' => 'Admin\BookingsController@create'
    ]);*/
});
