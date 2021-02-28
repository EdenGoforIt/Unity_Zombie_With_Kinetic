<?php

namespace App\Http\Controllers;

use App\Agency;
use Illuminate\Http\Request;

class AgenciesController extends Controller
{
    //['name','address','phone','details'];
    public function index()
    {
        $agencies = Agency::all();
        return view('admin.agencies.index', compact('agencies'));
    }
    public function show($id)
    {

        $agency = Agency::findOrFail($id);

        return view('admin.agencies.show', compact('agency'));
    }
    public function create()
    {
        //show template
        return view('admin.agencies.create');
    }


    public function store(Request $request)
    {

        //['name','address','phone','details'];
        $agency = Agency::create([
            'name' => $request->name,
            'address' => $request->address,
            'phone' => $request->phone,
            'details' => $request->details,
        ]);
        return redirect('/admin/agencies');
    }

    /**
     * Show the form for editing category.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {

        $agency = Agency::findOrFail($id);

        return view('admin.agencies.edit', compact('agency'));
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

        $agency = Agency::findOrFail($id);
        $agency->update($request->all());



        return redirect()->route('admin.agencies.index');
    }


    /**
     * Remove Booking from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {

        $agency = Agency::findOrFail($id);
        $agency->delete();

        return redirect()->route('admin.agencies.index');
    }

    /**
     * Delete all selected Category at once.
     *
     * @param Request $request
     */
    public function massDestroy(Request $request)
    {
        if (!Gate::allows('agency_delete')) {
            return abort(401);
        }
        if ($request->input('ids')) {
            $entries = Agency::whereIn('id', $request->input('ids'))->get();

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

        $agency = Agency::onlyTrashed()->findOrFail($id);
        $agency->restore();

        return redirect()->route('admin.agencies.index');
    }

    /**
     * Permanently delete Category from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function perma_del($id)
    {
        if (!Gate::allows('agency_delete')) {
            return abort(401);
        }
        $agency = Agency::onlyTrashed()->findOrFail($id);
        $agency->forceDelete();

        return redirect()->route('admin.agencies.index');
    }
}
