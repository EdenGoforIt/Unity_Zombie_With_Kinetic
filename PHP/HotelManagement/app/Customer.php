<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

/**
 * Class Customer
 *
 * @package App
 * @property string $first_name
 * @property string $last_name
 * @property string $address
 * @property string $phone
 * @property string $email
 * @property string $country
 */
class Customer extends Model
{
    use SoftDeletes;

    protected $fillable = ['first_name', 'last_name', 'address', 'phone', 'email', 'country_id', 'agency_id', 'company_id', 'details'];



    /**
     * Set to null if empty
     * @param $input
     */
    public function setCountryIdAttribute($input)
    {
        $this->attributes['country_id'] = $input ? $input : null;
    }

    public function country()
    {
        return $this->belongsTo(Country::class, 'country_id')->withTrashed();
    }

    public function agency() {
      return $this->belongsTo(Agency::class, 'agency_id');
    }

    public function company() {
      return $this->belongsTo(Company::class, 'company_id');
    }

    public function getFullNameAttribute()
    {
        return $this->first_name . ' ' . $this->last_name;
    }
}
