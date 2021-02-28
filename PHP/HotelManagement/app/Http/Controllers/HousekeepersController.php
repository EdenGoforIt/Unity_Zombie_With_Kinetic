<?php

namespace App\Http\Controllers;

use App\Housekeeper;
use Illuminate\Http\Request;

class HousekeepersController extends Controller
{
    // $table->string('name');
    // $table->string('address')->nullable();
    // $table->string('phone')->nullable();
    // $table->text('details')->nullable();
    public function index()
    {
        $housekeepers = Housekeeper::all();
        return view('admin.housekeepers.index', compact('housekeepers'));
    }

    public function create()
    {
        //show template
        return view('admin.housekeepers.create');
    }
    public function show($id)
    {
      
        $housekeeper = Housekeeper::findOrFail($id);

        return view('admin.housekeepers.show', compact('housekeeper'));
    }


    public function store(Request $request)
    {

        // ['start_time', 'end_time', 'total_cycle','schedule_id'];
        $housekeeper = Housekeeper::create([
            'name' => $request->name,

        ]);
        return redirect('/admin/housekeepers');
    }

    /**
     * Show the form for editing category.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {

        $housekeeper = Housekeeper::findOrFail($id);

        return view('admin.housekeepers.edit', compact('housekeeper'));
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

        $housekeeper = Housekeeper::findOrFail($id);
        $housekeeper->update($request->all());
        return redirect()->route('admin.housekeepers.index');
    }


    /**
     * Remove Booking from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {

        $housekeeper = Housekeeper::findOrFail($id);
        $housekeeper->delete();

        return redirect()->route('admin.housekeepers.index');
    }

    /**
     * Delete all selected Category at once.
     *
     * @param Request $request
     */
    public function massDestroy(Request $request)
    {
        if (!Gate::allows('housekeeper_delete')) {
            return abort(401);
        }
        if ($request->input('ids')) {
            $entries = Housekeeper::whereIn('id', $request->input('ids'))->get();

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
        if (!Gate::allows('housekeeper_delete')) {
            return abort(401);
        }
        $housekeeper = Housekeeper::onlyTrashed()->findOrFail($id);
        $housekeeper->restore();

        return redirect()->route('admin.housekeepers.index');
    }

    /**
     * Permanently delete Category from storage.
     *
     * @param  int $id
     * @return \Illuminate\Http\Response
     */
    public function perma_del($id)
    {
        if (!Gate::allows('housekeeper_delete')) {
            return abort(401);
        }
        $housekeeper = Housekeeper::onlyTrashed()->findOrFail($id);
        $housekeeper->forceDelete();

        return redirect()->route('admin.housekeepers.index');
    }
}
