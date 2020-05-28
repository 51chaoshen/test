using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPAVUE.Migrations
{
    public partial class update_attachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_common_attachment",
                table: "common_attachment");

            migrationBuilder.DropColumn(
                name: "ATTACHMENTID",
                table: "common_attachment");

            migrationBuilder.RenameTable(
                name: "common_attachment",
                newName: "CommonAttachment");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "CommonAttachment",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "SOURCEID",
                table: "CommonAttachment",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "REMARK",
                table: "CommonAttachment",
                newName: "Remark");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "CommonAttachment",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FILESIZE",
                table: "CommonAttachment",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "EXTENSON",
                table: "CommonAttachment",
                newName: "Extenson");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "CommonAttachment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CommonAttachment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "CommonAttachment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "CommonAttachment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "CommonAttachment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CommonAttachment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "CommonAttachment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "CommonAttachment",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommonAttachment",
                table: "CommonAttachment",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommonAttachment",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "CommonAttachment");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "CommonAttachment");

            migrationBuilder.RenameTable(
                name: "CommonAttachment",
                newName: "common_attachment");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "common_attachment",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "common_attachment",
                newName: "SOURCEID");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "common_attachment",
                newName: "REMARK");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "common_attachment",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "common_attachment",
                newName: "FILESIZE");

            migrationBuilder.RenameColumn(
                name: "Extenson",
                table: "common_attachment",
                newName: "EXTENSON");

            migrationBuilder.AddColumn<string>(
                name: "ATTACHMENTID",
                table: "common_attachment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_common_attachment",
                table: "common_attachment",
                column: "ATTACHMENTID");
        }
    }
}
