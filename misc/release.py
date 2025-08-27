import os
import zipfile
import sys

def make_release(tag, output_dir="."):
    version = tag.lstrip("v")  # strip leading v if present
    zip_name = f"WarBox{version}.zip"
    output_path = os.path.join(output_dir, zip_name)

    include = ["Code", "GameResource", "icon.png"]  # what to include
    with zipfile.ZipFile(output_path, "w", zipfile.ZIP_DEFLATED) as zf:
        for item in include:
            if os.path.isdir(item):
                for root, _, files in os.walk(item):
                    for f in files:
                        path = os.path.join(root, f)
                        arcname = os.path.relpath(path, ".")
                        zf.write(path, arcname)
            elif os.path.isfile(item):
                zf.write(item, item)
    print(f"Release package created: {output_path}")
    return output_path

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Usage: python release_packager.py <tag>")
        sys.exit(1)
    make_release(sys.argv[1])
