<?php

namespace App\Http\Controllers;

use App\Company;
use Illuminate\Http\Request;

class CompaniesController extends Controller
{
    // $table->string('name');
    // $table->string('address')->nullable();
    // $table->string('phone')->nullable();
    // $table->text('details')->nullable();
    public function index()
    {
        $companies = Company::all();
        return view('admin.companies.index', compact('companies'));
    }

    public function create()
    {
        //show template
        return view('admin.companies.create');
    }

    public function store(Request $request)
    {

        // ['start_time', 'end_time', 'total_cycle','schedule_id'];
        $company = Company::create([
            'name' => $request->name,
            'address' => $request->address,
            'phone' => $request->phone,
            'details' => $request->details,
        ]);
        return redirect('/admin/companies');
    }
    public function show($id)
    {

        $company = Company::findOrFail($id);

        return view('admin.companies.show', compact('company'));
    }

    /**
     * Show the form for editing category.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {

        $company = Company::findOrFail($id);

        return view('admin.companies.edit', compact('company'));
    }

    /**
     * Update category in storage.
     *
     * @param  \App\Http\Requests\UpdateCountriesRequest  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {

        $company = Company::findOrFail($id);
        $company->update($request->all());
        return redirect()->route('admin.companies.index');
    }


    /**
     * Remove Booking from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {

        $company = Company::findOrFail($id);
        $company->delete();

        return redirect()->route('admin.companies.index');
    }

    /**
     * Delete all selected Category at once.
     *
     * @param Request $request
     */
    public function massDestroy(Request $request)
    {
        if (!Gate::allows('company_delete')) {
            return abort(401);
        }
        if ($request->input('ids')) {
            $entries = Company::whereIn('id', $request->input('ids'))->get();

            foreach ($entries as $entry) {
                $entry->delete();
            }
        }
    }


    /**
     * Restore Category from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function restore($id)
    {
        if (!Gate::allows('company_delete')) {
            return abort(401);
        }
        $company = Company::onlyTrashed()->findOrFail($id);
        $company->restore();

        return redirect()->route('admin.companies.index');
    }

    /**
     * Permanently delete Category from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function perma_del($id)
    {
        if (!Gate::allows('company_delete')) {
            return abort(401);
        }
        $company = Company::onlyTrashed()->findOrFail($id);
        $company->forceDelete();

        return redirect()->route('admin.companies.index');
    }
}
