@extends('layouts.app')

@section('content')
<h3 class="page-title">Company</h3>
<!-- ['name','address','phone','details']; -->
<div class="panel panel-default">
    <div class="panel-heading">
        @lang('quickadmin.qa_view')
    </div>

    <div class="panel-body table-responsive">
        <div class="row">
            <div class="col-md-6">
                <table class="table table-bordered table-striped">
                    <tr>
                        <th>Name</th>
                        <td field-key='name'>{{ $company->name }}</td>
                    </tr>
                    <tr>
                        <th>Address</th>
                        <td field-key='name'>{{ $company->address }}</td>
                    </tr>
                    <tr>
                        <th>Phone</th>
                        <td field-key='name'>{{ $company->phone }}</td>
                    </tr>
                    <tr>
                        <th>Detail</th>
                        <td field-key='name'>{{ $company->detail }}</td>
                    </tr>

                </table>
            </div>
        </div><!-- Nav tabs -->


        <!-- Tab panes -->

        <p>&nbsp;</p>

        <a href="{{ route('admin.companies.index') }}" class="btn btn-default">@lang('quickadmin.qa_back_to_list')</a>
    </div>
</div>
@stop